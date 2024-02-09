<?php


// RETURNS 1 IF USER EXISTS; 0 OTHERWISE

if (isset($_POST['user'])) $user = $_POST['user'];
if (isset($_POST['psswrd'])) $psswrd = $_POST['psswrd'];


$file_name = 'users_registry.txt';


fopen($file_name,'a+');


$users_data = file_get_contents($file_name);

$rslt = FALSE;

if ($users_data != NULL) {

$rslt = check_user($user,$psswrd,$users_data);

 }; 


echo $rslt;

function check_user($user,$psswrd,$users_data) {

$users = explode(PHP_EOL,$users_data);

for ($i = 0; $i < count($users); $i++) {

if (json_decode($users[$i])->user == $user && json_decode($users[$i])->psswrd == $psswrd) $rslt = TRUE;

  }; 

return $rslt;

  };



?> 


