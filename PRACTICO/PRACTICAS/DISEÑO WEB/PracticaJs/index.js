function convertirHora(){
    let inputHora24 = document.getElementById('hora24')
    let inputMin24 = document.getElementById('min24')

    let inputHora12 = document.getElementById('salida12')
    let valorHora24 = parseInt(inputHora24.value)
    let valorMin24 = parseInt(inputMin24.value)

    if(valorHora24 == 0)
        inputHora12.value = (valorHora24 + 12) + ':' + valorMin24 + ' AM'
    else 
        if(valorHora24 >0 && valorHora24 < 12)
            inputHora12.value = (valorHora24) + ':' +  valorMin24 + ' AM'
        else
            inputHora12.value = (valorHora24 - 12) + ':' +  valorMin24 + ' PM'
        
}   