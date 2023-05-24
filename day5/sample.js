function arrayOperation(){
    var array = [1,2,3,4,5,6,7,8,9,10]
    // PUSH & POP
    array.push(11)
    console.log(array)
    array.pop()
    console.log(array)

    // SLICE

    array.splice(5,3)
    console.log("after slice : " , array)

    // Length of array
    console.log(array.length)
}
