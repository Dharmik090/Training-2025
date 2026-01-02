setTimeout(() => {
  document.getElementById("one").textContent = "1 second passed";
  setTimeout(() => {
    document.getElementById("two").textContent = "2 seconds passed";
    setTimeout(() => {
      document.getElementById("three").textContent = "3 seconds passed";
      setTimeout(() => {
        document.getElementById("four").textContent = "4 seconds passed";
      }, 1000);
    }, 1000);
  }, 1000);
}, 1000);
