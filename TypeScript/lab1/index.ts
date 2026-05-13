// 1. 
interface User {
    name: string;
    age: number;
}

const user: Pick<User, "name"> = {
    name: "John"
};

console.log(user);

// 2. 
interface Profile {
    username?: string;
    email?: string;
}

const profile: Required<Profile> = {
    username: "john",
    email: "john@gmail.com"
};

console.log(profile);

// 3.
type Colors = Record<"red" | "green" | "blue", string>;

const colors: Colors = {
    red: "#ff0000",
    green: "#00ff00",
    blue: "#0000ff"
};

console.log(colors.red);

// 4.
interface Person {
    name: string;
    age: number;
    email: string;
}

type PersonWithNameAndEmail = Pick<Person, "name" | "email">;

const person: PersonWithNameAndEmail = {
    name: "mohamed",
    email: "mohamed@gmail.com"
};

console.log(person);

// 5.
interface Person {
  name: string;
  age: number;
  email: string;
}

type PersonWithoutAge = Omit<Person, "age">;

const personWithoutAge: PersonWithoutAge = {
    name: "atef",
    email: "atef@gmail.com"
};

console.log(personWithoutAge);

// 6.
type Color = "red" | "green" | "blue" | "yellow";
type ColorWithoutYellow = Exclude<Color, "yellow">;
const color: ColorWithoutYellow = "red";
console.log(color);

// 7.
type ColorRedOrBlue = Extract<Color, "red" | "blue">;
const colorRedOrBlue: ColorRedOrBlue = "red";
console.log(colorRedOrBlue);

// 8.
type MaybeString = string | null | undefined;
type NonNullString = NonNullable<MaybeString>;
const nonNullString: NonNullString = "hello";
console.log(nonNullString);