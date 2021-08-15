GetUsers();

var btn;
btn = document.querySelector("#save");
btn.addEventListener("click", SaveUser);

btn = document.querySelector("#cancel");
btn.addEventListener("click", CancelUser);

var method = "POST";
var _id;

async function SaveUser() {
    var name = document.querySelector("#name").value;
    var age = parseInt(document.querySelector("#age").value, 10) || 0;
    var body = JSON.stringify({ name: name, age: age });

    const response = await fetch("api/Users/" + (_id || ""), {
        method: method,
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: body
    });
    if (response.ok === true) {
        GetUsers();
    }
}

async function GetUser(id) {
    _id = id;
    const response = await fetch("api/Users/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const user = await response.json();
        document.querySelector("#name").value = user.name;
        document.querySelector("#age").value = user.age;
    }
}

function CancelUser() {
    document.querySelector("#name").value = "";
    document.querySelector("#age").value = "";
    method = "POST";
    document.querySelector("#save").innerHTML = "Add User";
    _id = null;
}

function EditUser(id) {
    method = "PUT";
    document.querySelector("#save").innerHTML = "Save User";
    GetUser(id);
}

function DeleteUser(id) {
    method = "DELETE";
    document.querySelector("#save").innerHTML = "Delete User";
    GetUser(id);
}

async function GetUsers() {
    CancelUser();
    const response = await fetch("api/Users", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const users = await response.json();
        var table = document.querySelector('#users tbody');
        table.innerHTML = "";
        users.forEach(user => {
            table.appendChild(row(user));
        });
    }
}

function row(user) {
    var tr = document.createElement("tr");
    var td, text, link;

    td = document.createElement("td");
    text = document.createTextNode(user.id);
    td.appendChild(text);
    tr.appendChild(td);

    td = document.createElement("td");
    text = document.createTextNode(user.name);
    td.appendChild(text);
    tr.appendChild(td);

    td = document.createElement("td");
    text = document.createTextNode(user.age);
    td.appendChild(text);
    tr.appendChild(td);

    td = document.createElement("td");

    link = document.createElement("a");
    link.setAttribute("href", "#");
    link.addEventListener("click", e => EditUser(user.id));
    text = document.createTextNode("Edit");
    link.appendChild(text);
    td.appendChild(link);

    text = document.createTextNode(" | ");
    td.appendChild(text);

    link = document.createElement("a");
    link.setAttribute("href", "#");
    link.addEventListener("click", e => DeleteUser(user.id));
    text = document.createTextNode("Delete");
    link.appendChild(text);
    td.appendChild(link);

    tr.appendChild(td);

    return tr;
}