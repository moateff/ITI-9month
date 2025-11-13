#include <iostream>
using namespace std;

int main() {
    int total_students, total_subjects;

    cout << "Please enter number of students and number of subjects: ";
    cin >> total_students >> total_subjects;

    int grades[total_students][total_subjects];
    int student_total[total_students] = {0};      // Sum of grades for each student
    int subject_total[total_subjects] = {0};      // Sum of grades for each subject

    for (int student = 0; student < total_students; student++) {
        for (int subject = 0; subject < total_subjects; subject++) {
            cout << "Enter grade of subject " << subject + 1 
                 << " for student " << student + 1 << ": ";
            cin >> grades[student][subject];

            student_total[student] += grades[student][subject];  
            subject_total[subject] += grades[student][subject];  
        }
    }

    cout << "\nSum of grades for each student:\n";
    for (int i = 0; i < total_students; i++) {
        cout << "Student " << i + 1 << ": " << student_total[i] << endl;
    }

    cout << "\nAverage grade for each subject:\n";
    for (int i = 0; i < total_subjects; i++) {
        cout << "Subject " << i + 1 << ": " 
             << double(subject_total[i]) / total_students << endl;
    }

    return 0;
}
