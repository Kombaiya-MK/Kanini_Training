var names = []
function addName(){
    var name = document.getElementById('txtNmae').value
    names.push(name)
    document.getElementById('txtNmae').value = ""
}

function showName(){
    var MyDiv = document.getElementById("msgDiv");
    MyDiv.innerHTML = names
}

var num = 234; // global variable
function variableScope(){
    var num = 123; // local variable
    console.log(num + window.num)

}