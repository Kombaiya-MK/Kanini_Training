
var customer = {
    "id" : null,
    "name":"",
    "age": null
}

var customerdata = []

function addCustomerData(){

    customer = new Object();
    customer.id = document.getElementById("CusId").value * 1;
    customer.name = document.getElementById("CusName").value;
    customer.age = document.getElementById("CusAge").value * 1;
    customerdata.push(customer)

    document.getElementById("CusId").value = ""
    document.getElementById("CusName").value = ""
    document.getElementById("CusAge").value = ""
}


function showCustomerData(){
    for(var i = 0; i < customerdata.length; i++)
    {
        data = "Customer ID : " + customerdata[i].id + "\t Customer Name :  " + customerdata[i].name + "\t Customer Age : " + customerdata[i].age
        console.log(data)
    }
}