// Variable and data types
const name = "name";
const age = 0;
const education = "education";
const favoriteSubjects = ["Subject1", "Subject2", "Subject3"];

const contactInfo = {
    email: "email@email.com",
    phoneNumber: "+46 070-1234567"
};

console.log("Name: ", name);
console.log("Age: ", age);
console.log("Education: ", education);
console.log("Favorite subject: ", favoriteSubjects.join(", "));
console.log("Contact:",contactInfo.email + ", " + contactInfo.phoneNumber);

favoriteSubjects.push("Subject4");

contactInfo.email = "newEmail@email.com";

console.log("Update");
console.log("Favorite subject: ", favoriteSubjects.join(", "));
console.log("Contact:",contactInfo.email + ", " + contactInfo.phoneNumber);

// Conditions and decisions
const points = 100;

if (points >= 90 && points <= 100) {
    console.log("A, Well done!");
} else if(points >= 80 && points <= 89) {
    console.log("B");
} else if(points >= 70 && points <= 79) {
    console.log("C");
} else if(points >= 60 && points <= 69) {
    console.log("D");
} else if(points >= 50 && points <= 59) {
    console.log("E");
}else if(points < 50) {
    console.log("F");
}else{
    console.log("Invalid");
}

function grade(inPoints) {
    if (inPoints >= 90 && inPoints <= 100) {
        console.log("A");
    } else if(inPoints >= 80 && inPoints <= 89) {
        console.log("B");
    } else if(inPoints >= 70 && inPoints <= 79) {
        console.log("C");
    } else if(inPoints >= 60 && inPoints <= 69) {
        console.log("D");
    } else if(inPoints >= 50 && inPoints <= 59) {
        console.log("E");
    }else if(inPoints < 50) {
        console.log("F");
    }else{
        console.log("Invalid");
    }
}

grade(100);
grade(80);
grade(70);
grade(60);
grade(50);
grade(40);

// Loops and arrays

const tasks = ["Read about JavaScript", "Code Excersise 1", "Fika", "Program together", "Repeat CSS"]
for (const [index, task] of tasks.entries()) {
    console.log(`${index}. ${task}`);
}

const codeCounter = 0;
const programCounter = 0;

for (let task of tasks){
    if()
}