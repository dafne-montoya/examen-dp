<?php
// Dilian Dafne Montoya Herrera -- Práctica 1 REST API

// Obtener datos desde la URL
$datos = file_get_contents('https://my-json-server.typicode.com/dp-danielortiz/dptest_jsonplaceholder/items');
//Convertir a JSON
$objetos = json_decode($datos);

echo "-- ELEMENTOS DE COLOR ROJO -- <br>";

//Recorrer el JSON
foreach ($objetos as $objeto) {
    if ($objeto->color === 'red') { // Verificar qué elementos tienen "color": red
        foreach ($objeto as $k=>$v){
            echo "$k : $v <br>"; //Imprimir 
        }
        echo "<br>";
    }
}

?>