//Desarrollar un programa JavaScript que genere aleatoriamente 100 números enteros y los guarde en
//un arreglo unidimensional. A continuación, calcula y muestra por separado la media de los valores
//positivos y la de los valores negativos.

function procesar(){
    let contador = 0;
    let contadorPositivos = 0;
    let contadorNegativos = 0;
    let array = [];
    let acumuladorPositivo = 0;
    let acumuladorNegativo = 0;

    for(let i = 0; i<100; 100){
        let num = Math.floor(Math.random()*100)-50;
        if(num > 0){
            acumuladorPositivo = acumuladorPositivo + num;
            contadorPositivos++;
        }
        else{
            acumuladorNegativo = acumuladorNegativo + num;
            contadorNegativos++;
        }
        array.push(num);

        let mediaPositivos = acumuladorPositivo/contadorPositivos;
        let mediaNegativos = acumuladorNegativo/contadorNegativos;
        
        console.log(mediaPositivos);
        console.log(mediaNegativos)

        array.forEach(element => {
            console.log(element)
        })
    }
}