<?php // Dilian Dafne Montoya Herrera -- Práctica 1 REST API

function consumirRecurso() {
    // Obtener datos desde la URL
    $datos = file_get_contents('https://my-json-server.typicode.com/dp-danielortiz/dptest_jsonplaceholder/items');
    //Convertir a JSON
    $objetos = json_decode($datos);
    // Crear un array temporal para almacenar los resultados
    $array_datos = array();

    //Recorrer el JSON
    for($i=0; $i<count($objetos); $i++) {
        if ($objetos[$i]->color === 'green') { // Verificar qué elementos tienen "color": green
            array_push($array_datos, $objetos[$i]); //Guardar los datos en un arreglo temporal de datos
        }
    }

    // Guardar resultados filtrados y formateados en un archivo .json
    $datos_json = json_encode($array_datos);
    $file = 'Respuesta1.json';
    file_put_contents($file, $datos_json);
}

?>

<input type="submit" name="" value="Consumir Recurso API" id="botonAPI" onclick = "funcion();">
<script>
    function funcion(){
        <?php echo consumirRecurso(); ?>
        alert("Se ha realizado la acción");
    }
</script>