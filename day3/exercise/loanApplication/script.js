var customer = {
    "name":"",
    "age" : 0,
    "dob" : "",
    "email": "",
    "phnumber":"",
    "Gender":"",
    "fname":""
}
var financial_info = {
    "yearly_income" : 0,
    "monthly_allowance":0,
    "salaried":"",
    "previous_loan" : ""
}
var loan_info = {
    "loan_amount":0,
    "tenure":0,
    "loan_type":"",
    "CIBIL_score":0
}

var loan_details = []
function addBasicInfo(){
    // console.log("bjsabj")
    customer = new Object()
    customer.name = document.getElementById("txtname").value
    customer.age = document.getElementById("txtage").value
    customer.dob = document.getElementById("date").value
    customer.email = document.getElementById("mail").value
    customer.phnumber = document.getElementById("phnumber").value
    // customer.Gender = document.g
    window.loan_details.push(customer)
    console.log(customer)
    console.log(loan_details)
}

function addFinancialInfo(){
    financial_info = new Object()
    financial_info.yearly_income = document.getElementById("txtincome").value
    financial_info.monthly_allowance = document.getElementById("allowance").value
    financial_info.previous_loan = document.getElementById("loandetails").value
    
    console.log(financial_info)
    loan_details.push(financial_info)
    console.log(loan_details)
}

function addLoanInfo(){
    loan_info = new Object()
    loan_info.loan_amount = document.getElementById("loanamount").value
    loan_info.tenure = document.getElementById("tenure").value
    loan_info.loan_type = document.getElementById("loanTypee").value
    loan_info.CIBIL_score = document.getElementById("cscore").value
    console.log(loan_info)
    loan_details.push(loan_info)
    console.log(loan_details)
}
