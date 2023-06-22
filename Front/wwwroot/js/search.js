const form = document.querySelector('form');

form.addEventListener('submit', (e) => {
    e.preventDefault();
    searchRq = document.getElementById("searchfield").value
    const formData = new FormData(form);
    // Send POST request to the backend API endpoint
    fetch('/api/writes', {
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (response.ok) {
                if (searchRq == "fight") { window.location.href = 'listpage.html'; }
                else {
                    if (searchRq == "diploma") { window.location.href = 'Iistpage.html'; }
                    else {
                        window.location.href = 'noresults.html';
                    } }
               
                 
            } else {
                throw new Error('Error occurred while posting the data.');
            }
        })
        .catch(error => {
            console.error(error);
        });
});



