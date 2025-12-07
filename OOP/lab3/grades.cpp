#include <iostream>
using namespace std;

int main() {
    int total_students, total_subjects;

    cout << "Please enter number of students and number of subjects: ";
    cin >> total_students >> total_subjects;

    int grades[total_students][total_subjects];
    int student_total[total_students] = {0};      // Sum of grades for each student
    int subject_total[total_subjects] = {0};      // Sum of grades for each subject

    for (int i = 0; i < total_students; i++) {
        for (int j = 0; j < total_subjects; j++) {
            cout << "Enter grade of subject " << j + 1 << " for student " << i + 1 << ": ";
            cin >> grades[i][j];

            student_total[i] += grades[i][j];  
            subject_total[j] += grades[i][j];  
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
