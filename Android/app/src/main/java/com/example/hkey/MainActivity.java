package com.example.hkey;

import android.os.Bundle;
import android.os.Vibrator;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

public class MainActivity extends AppCompatActivity {
    Button pin;
    Button shut,restart,task;
    TextView t;
    Vibrator Vibrator;
    DatabaseReference reff;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        pin= findViewById(R.id.pin);
        task= findViewById(R.id.Task);
        shut = findViewById(R.id.shut);
        restart = findViewById(R.id.Restart);
        t=findViewById(R.id.value);
        pin.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view) {
                Vibrator.vibrate(18);
                reff= FirebaseDatabase.getInstance().getReference();
                reff.addValueEventListener(new ValueEventListener() {
                    @Override
                    public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                        String name=dataSnapshot.child("pin").getValue ().toString();
                        t.setText(name);
                    }
                    @Override
                    public void onCancelled(@NonNull DatabaseError databaseError) {
                    }
                });
            }
        });


       

    }
}
