var items={
    name:'',
    price:0
}



var total=0;
var i=-1;
var array=[];
function login(){
    var name = document.getElementById("txtName").value;
    var password = document.getElementById("txtPassword").value


    if (name != 'Mksuresh' && password != '12345')
    {
        alert("Invalid Username or Password")

    }
    else{
        window.open('home.html')
    }
}

function myFunction(names,prices){
    items.name=names;
    items.price=prices;
    total+=prices*1;
    i++;
    array.push(items);
    var body_table = document.getElementById("table-body");
    var new_row = document.createElement("tr");
    var data = "<td>" + array[i].name + "</td>"+ "<td>" + array[i].price + "</td>";
    console.log(data);
    document.getElementById("total").innerHTML = total;
    new_row.innerHTML = data;
    body_table.append(new_row);
    console.log(body_table);
    event.preventDefault();
}

function clears(){
    for(let j = i-1; j >= 0;j--)
    {
        document.getElementById("table-body").deleteRow(j);
        i--;
    }
}

