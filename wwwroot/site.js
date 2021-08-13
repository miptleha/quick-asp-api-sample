GetUsers();

async function GetUsers() {
    const response = await fetch("api/Users", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const users = await response.json();
        let dest = document.querySelector("#users");
        var table = document.createElement('table');
        dest.appendChild(table);
        users.forEach(user => {
            var tr = document.createElement("tr");
            table.appendChild(tr);

            var td = document.createElement("td");
            var text = document.createTextNode(user.name);
            td.appendChild(text);
            tr.appendChild(td);

            var td = document.createElement("td");
            var text = document.createTextNode(user.age);
            td.appendChild(text);
            tr.appendChild(td);
        });
    }
}