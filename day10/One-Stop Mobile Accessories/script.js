function costCalculation(){
    var name = document.getElementById("name").value
    var phnumber = document.getElementById("phoneNumber").value*1
    var email = document.getElementById("emailId").value
    var address = document.getElementById("address")
    var total_amount = 0
    var option1 = document.getElementById("option1")
    var option2 = document.getElementById("option2")
    var option3 = document.getElementById("option3")
    var option4 = document.getElementById("option4")
    var option5 = document.getElementById("option5")
    var msg = ""
    if (option1.checked == true)
    {
        total_amount += 799
    }
    if (option2.checked == true)
    {
        total_amount += 899
    }
    if (option1.checked == true)
    {
        total_amount += 1199
    }
    if (option1.checked == true)
    {
        total_amount += 299
    }
    if (option1.checked == true)
    {
        total_amount += 999
    }
    if (total_amount >= 2000)
    {
        var discount = total_amount * (20/100)
        total_amount = total_amount - discount
    }
    if (total_amount == 0)
    {
        msg = "No selection has been made."
    }
    console.log(total_amount)


}