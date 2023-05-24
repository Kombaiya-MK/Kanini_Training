var movie = {
    "sno" : 0,
    "name" : "" ,
    "duration": 0,
    "rating" : 0
}

var movies = []
var cnt = 0

function assignMovieData(){
    movie = new Object()
    // movie.sno = 0
    // cnt += 1
    // movie.name = ""
    // movie.duration = 0
    // movie.rating = 0
    movie.name = document.getElementById("MovName").value
    movie.duration = document.getElementById("MovDuration").value * 1
    movie.rating = document.getElementById("MovRating").value * 1
    console.log(movie)

    movies.push(movie)
    cnt += 1;
    showMovieData()
    document.getElementById("MovName").value = ""
    document.getElementById("MovDuration").value = ""
    document.getElementById("MovRating").value = 0
    console.log(movies)
}

function showMovieData(){
    var Mytab = document.getElementById("newTable");
    tb = document.createElement("tr")
    tb.innerHTML = "<td>" + movies[cnt-1].name + "</td>" + "<td>" + movies[cnt-1].duration + "</td>"+ " <td>" + movies[cnt - 1].rating + "</td>" ;
    Mytab.append(tb)
}
