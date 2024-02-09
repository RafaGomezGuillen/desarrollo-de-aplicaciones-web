<?php

// RETURS THE PASSWORD STRING FOR AN ALREADY EXISTING USER

if (isset($_POST['email'])) $email = $_POST['email'];

$file_name = 'users_registry.txt';


fopen($file_name,'a+');


$users_data = file_get_contents($file_name);


$psswrd = NULL;

if ($users_data != NULL) {

$psswrd = recover_psswrd($email,$users_data);

 }; 


echo $psswrd;


function recover_psswrd($email,$users_data) {

$users = explode(PHP_EOL,$users_data);

for ($i = 0; $i < count($users); $i++) {

if (json_decode($users[$i])->email == $email) $psswrd = json_decode($users[$i])->psswrd;

  }; 

return $psswrd;

  };



?> 


