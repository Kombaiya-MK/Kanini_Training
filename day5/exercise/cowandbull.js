var storage = []
var game = {
    "cows" : 0 ,
    "bulls": 0 ,
    "text" : "" ,
    "word" : ""

}
function getText(){
    game = new Object()
    game.cows = 0
    game.bulls = 0
    game.text = document.getElementById("txtName").value
    game.word = document.getElementById("txtGuess").value
    
    if (game.text.length != game.word.length)
    {
        var MyDiv = document.getElementById("msgDiv");
        MyDiv.innerHTML = "The length of the two strings are mismatched!"
    }
    for(var i = 0;i<game.word.length;i++)
    {
        for(var j = 0 ; j < game.word.length;j++)
        {
            if (game.text[i] == game.word[j] && i == j)
            {
                game.cows += 1
                break
            }
            else if (game.text[i] == game.word[j] && i != j)
            {
                game.bulls += 1
                break
            }
        }
    }

    if (game.cows == game.word.length)
    {
        alert("Congrats! you find the correct word..")
    }
    result = "Actual text : " + game.word + "  Entered Text : " + game.text + "  Cows : " + game.cows + "  Bulls : " + game.bulls
    storage.push(result)
    document.getElementById("txtName").value = ""
    document.getElementById("txtGuess").value = ""

}

function showResult(){
    var MyDiv = document.getElementById("msgDiv");
    for(var i = 0 ; i < storage.length;i++)
    {
        MyDiv.innerHTML = storage[i]
        console.log(storage[i])
    }
}