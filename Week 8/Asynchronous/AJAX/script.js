let population = document.getElementById("population");
let img = document.getElementById("flag");
let countryBox = document.getElementById("cname");

countryBox.addEventListener("change", getCountryDetails);

function getCountryDetails() {
  let country = countryBox.value;
  let req = new XMLHttpRequest();

  
  req.open("GET", `https://restcountries.com/v3.1/name/${country}`);

  req.send();

  req.addEventListener("load", function () {
    const res = JSON.parse(this.responseText)[0];

    console.log(res);
    // cname.textContent = res.name;

    img.src = res.flags.png;
    population.textContent = "Population :  " + res.population;
  });
}

getCountryDetails();
