<?php

// RETURNS 'Y' IN CASE OF NON NULL DATA RECEIVED; 'N' OTHERWISE


if (isset($_POST['data'])) $data = $_POST['data'];

$file_name = 'bets_registry.txt';

fopen($file_name,'a+');


$json = json_decode($data);
$data = json_encode($json);

if ($data != NULL) {

file_put_contents($file_name, $data.PHP_EOL,FILE_APPEND);

echo 'Y'; } else { echo 'N';}



?> 
