<?php


// RETURNS ARRAY BETS FOR SELECTED USER; 'N'  OTHERWISE

if (isset($_POST['user'])) $user = $_POST['user'];
if (isset($_POST['psswrd'])) $psswrd = $_POST['psswrd'];


$file_name = 'bets_registry.txt';


fopen($file_name,'a+');


$users_data = explode(PHP_EOL,file_get_contents($file_name));

$bets = check_bets($user,$psswrd,$users_data);


if (count($bets) == 0) echo 'N';
if (count($bets) > 0) echo json_encode($bets);


function check_bets($user,$psswrd,$users_data) {

$bets =  array();


for ($i = 0; $i < count($users_data); $i++) {

if ($users_data[$i] != NULL) {

if (json_decode($users_data[$i])->user == $user && json_decode($users_data[$i])->passwrd == $psswrd) array_push($bets,$users_data[$i]);

  };

      }

return $bets;

  };



?> 


