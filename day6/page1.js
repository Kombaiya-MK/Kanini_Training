var data = "<p>BAKJAJKNAJK OJANKNM kamnklnxmlx  MCANKSNKM jdnSN M MS </p>"

function onClick(){
    document.getElementById('div1').innerHTML = data;
}

function getBody(){
    bodyEle = document.body
    console.log(bodyEle)
}

function getDivs(){
    divEle = document.getElementsByTagName("div")
    console.log(divEle[0])
}

function addButton(){
    bodyEle = document.body
    var myButton = document.createElement('button')
    console.log(myButton)
    myButton.innerHTML = "New  Button"
    myButton.id = "button1"
    // myButton.addEventListener("click", addEvent)
    myButton.addEventListener("click", function(){
        alert("New Button added!!!")
    })
    bodyEle.append(myButton)
    console.log(myButton)
    // bodyEle.
}

function addEvent(){
    alert("New Button added!!!")
}