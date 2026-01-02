const scores = [45, 78, 92, 30, 65, 51.5, "NaN"];

function calculateStatus(score) {
    if (typeof score !== "number") {
        throw new TypeError("Score must be a number");
    }

    return score > 50 ? "Pass" : "Fail";
}

scores.forEach((score, index) => {
    const status = calculateStatus(score);
    
    console.log(`Student ${index + 1}: Score = ${score}, Status = ${status}`);
});