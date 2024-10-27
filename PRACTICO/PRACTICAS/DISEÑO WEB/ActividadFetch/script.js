function consultar() {
    fetch('https://jsonplaceholder.org/users')
    .then(response => response.json())
    .then(data => {
        const listaUsuarios = document.getElementById('lista'); 
        listaUsuarios.innerHTML = ''; 
        data.forEach(element => {
            const li = document.createElement('li');
            li.innerHTML = element.firstname + ', ' + element.lastname + ' - ' + element.email;
            listaUsuarios.appendChild(li);
        });
    })
    .catch(error => {
        console.error('Error:', error);
    });
}  