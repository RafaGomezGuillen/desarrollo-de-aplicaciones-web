<?php

// RETURNS PASSWORD STRING FOR A NEW USER

if (isset($_POST['new_user'])) $data = $_POST['new_user'];

$file_name = 'users_registry.txt';


fopen($file_name,'a+');


$users_data = file_get_contents($file_name);


$psswrd = gen_psswrd($length = 10);


if ($users_data  != NULL) {


$ctrl = -1;

while ($ctrl < 0) {
$psswrd = gen_psswrd($length = 10);
$ctrl = check_psswrd($psswrd, $users_data);
}

   };


$json = json_decode($data);
$json->psswrd = $psswrd;
$data = json_encode($json);

file_put_contents($file_name, $data.PHP_EOL,FILE_APPEND);

echo $psswrd;

function gen_psswrd($length) {
  $chars =  'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'.
            '0123456789-~!@#$%^&*()_,./<>?;:[]{}\|';

  $str = '';
  $max = strlen($chars) - 1;

  for ($i=0; $i < $length; $i++)
    $str .= $chars[random_int(0, $max)];

  return $str;
}


function check_psswrd($psswrd, $users_data) {

$users = explode(PHP_EOL,$users_data);

$ctrl = 1;

for ($i = 0; $i < count($users); $i++) {

if (json_decode($users[$i])->psswrd == $psswrd) $ctrl = -1;

  }; 

return $ctrl;

  };



?> 


