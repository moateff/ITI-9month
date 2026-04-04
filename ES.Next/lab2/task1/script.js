function generateCourseInfo(course = {}) {
    const allowedProps = ["courseName", "courseDuration", "courseOwner"];

    const extraProps = Object.keys(course).filter(key => !allowedProps.includes(key));
    if (extraProps.length > 0) {
        throw new Error(`Invalid properties passed: ${extraProps.join(", ")}`);
    }
    
    // Destructure with default values
    const {
        courseName = "ES6",
        courseDuration = "3days",
        courseOwner = "JavaScript"
    } = course;

    console.log(`Course Name: ${courseName}`);
    console.log(`Course Duration: ${courseDuration}`);
    console.log(`Course Owner: ${courseOwner}`);
    console.log();
}

generateCourseInfo({
    courseName: "Advanced JS",
    courseDuration: "5days",
    courseOwner: "Mohamed Atef"
});

generateCourseInfo({ courseName: "NodeJS" });

try {
    generateCourseInfo({ 
        courseName: "NodeJS", 
        level: "Beginner" 
    });
} catch (e) {
    console.log(e.message + "\n");
}
