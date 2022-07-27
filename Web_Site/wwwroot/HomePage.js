 function createnewUser(){
    document.getElementById("update").style.display = "block";

}

function newUser() {
    //document.getElementById("emailu").
    let user = {
        IdentityNum: document.getElementById("userIdentity").value,
        Password: document.getElementById("userPassword").value,
        Mail: document.getElementById("userMail").value,
        Name: document.getElementById("userName").value,
        Phone: document.getElementById("userPhone").value,
        Status: 4,
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
}

function login() {

    let password = document.getElementById("password").value;
    let identity = document.getElementById("identity").value;

    fetch("api/user/" + password + "/" + identity)
        .then((data) => {
            if (data.ok) {
                return data.json();
            }
            else {
                throw new Error("user not exist!!");
            }

        })
        .then((dataJson) => {
            alert("hello to " + dataJson.name + " we happy to meet you here!");
            sessionStorage.setItem('user', JSON.stringify(dataJson))
            window.location.href = "updateUser.html"
        })
        .catch((error) => {
            alert("user not exist 222222222222!!");
        })

}


