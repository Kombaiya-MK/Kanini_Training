function billCalculation(){
    console.log("hjdwjns,md")
    var member_count = 0
    customer_name = document.getElementById("customerName").value
    customer_contact = document.getElementById("contactNo").value * 1
    booking_date = document.getElementById("bookingDate").value
    veg_adults = document.getElementById("vegAdult").value*1
    veg_kids =  document.getElementById("vegKids").value*1
    non_veg_adults = document.getElementById("nonVegAdult").value*1
    non_veg_kids = document.getElementById("nonVegKids").value*1
    console.log(veg_adults)
    member_count = veg_adults + veg_kids + non_veg_adults + non_veg_kids
    console.log(member_count)
    var original_cost = (veg_adults * 599) + (veg_kids*249) + (non_veg_adults * 699) + (non_veg_kids * 349)
    var gst = (original_cost) * (12 / 100)
    var net_price = original_cost + gst
    var discount = 0
    if (member_count >= 10){
        discount = (net_price) * (10/100)
    }
    net_price = net_price - discount
    console.log(net_price)
    var MyDiv = document.getElementById("msgDiv");
    if (customer_name == "" || customer_contact == "" || booking_date == "")
    {
        MyDiv.innerHTML = "Fill all details!!!"
    }
    else{
        MyDiv.innerHTML = "Hai " + customer_name + ",You have to pay Rs." + net_price.toFixed(2) + ". Thanks for coming!!!"
    }
    // var MyDiv = document.getElementById("msgDiv");
}