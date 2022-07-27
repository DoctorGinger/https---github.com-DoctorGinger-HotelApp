function newUser() {
    let user = {
        Id:0,
        Password: document.getElementById("password").value,
        Email: document.getElementById("email").value,
        Name: document.getElementById("name").value

    }
    fetch("api/user", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user),
    })
        .then((data) => {
            if (data.ok)

                return data;


            throw new Error("status code is:" + response.status);
        })
        .then(data => data.json()).then(data => {

            alert("ussigned successfully!!! Mr.: " + data.name);
        })
//.catch ((error) => { alert(error); })

            

                
           



      




}