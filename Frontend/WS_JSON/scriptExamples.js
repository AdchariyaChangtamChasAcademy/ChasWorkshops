const student = {
    name : "Alice",
    age : 25,
    courses : ["frontend", "backend", "databases"],
    contact : {
        email : "alice@email.com",
        phone : "070-1234567"
    },
    graduated : false
}
console.log('Student-objekt:', student);

// JSON.stringyfy();
const jsonstring = JSON.stringify(student);
console.log('JSON-string:', jsonstring);

const prettyJson = JSON.stringify(student, null, 2);
console.log('JSON-pretty:\n', prettyJson);

// JSON.parse()
const parsedStudent = JSON.parse(jsonstring);
console.log('Parsed-object:\n', parsedStudent);

// Examples
console.log('Name:', parsedStudent.name);
console.log('First Course:', parsedStudent.courses[0]);

const invvalidJson = '{name: "Bob"}';
try{
    const obj = JSON.parse(invvalidJson);
} catch (error){
    console.error('Invalid-JSON', error.message)
};