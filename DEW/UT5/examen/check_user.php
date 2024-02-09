<?php


// RETURNS 1 IF USER EXISTS; NULL OTHERWISE

if (isset($_POST['user'])) $user = $_POST['user'];
if (isset($_POST['psswrd'])) $psswrd = $_POST['psswrd'];


$file_name = 'users_registry.txt';


fopen($file_name,'a+');


$users_data = explode(PHP_EOL,file_get_contents($file_name));

$rslt = FALSE;

if ($users_data != NULL) {

$rslt = check_user($user,$psswrd,$users_data);

 }; 


echo $rslt;

function check_user($user,$psswrd,$users_data) {


for ($i = 0; $i < count($users_data); $i++) {

if ($users_data[$i] != NULL && json_decode($users_data[$i])->user == $user && json_decode($users_data[$i])->psswrd == $psswrd) $rslt = TRUE;

  }; 

return $rslt;

  };



?> 


