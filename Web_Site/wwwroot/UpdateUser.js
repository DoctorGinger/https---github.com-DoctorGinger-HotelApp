function show() {
    document.getElementById("mail").value = JSON.parse(sessionStorage.getItem('user')).mail;
    document.getElementById("name").value = JSON.parse(sessionStorage.getItem('user')).name;
    document.getElementById("password").value = JSON.parse(sessionStorage.getItem('user')).password;
    document.getElementById("phone").value = JSON.parse(sessionStorage.getItem('user')).phone;
}

function update() {
   
    let user = {
        IdentityNum: JSON.parse(sessionStorage.getItem('user')).identityNum,
        Password: document.getElementById("password").value,
        Mail: document.getElementById("mail").value,
        Name: document.getElementById("name").value,
        Phone: document.getElementById("phone").value,
        Id: JSON.parse(sessionStorage.getItem('user')).id,
        Status: JSON.parse(sessionStorage.getItem('user')).status
    }
    fetch("https://localhost:44329/api/user/" + user.Id, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user),
    })
    .then((data) => {
        if (data.ok)
            alert(user.Name + " updated successfully");
       // throw new Error("update fail:");
    })
    //.then(data => data.json()).then(data => {

    //    alert("updated successfully!!! Mr.: " + data.name);
    //})


}