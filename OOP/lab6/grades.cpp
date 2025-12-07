#include <iostream>
using namespace std;

int main() {
    int total_students, total_subjects;

    cout << "Please enter number of students and number of subjects: ";
    cin >> total_students >> total_subjects;

    // Dynamically allocate 2D array for grades
    int** grades = new int*[total_students];
    for (int i = 0; i < total_students; i++) {
        grades[i] = new int[total_subjects];
    }

    // Dynamic arrays for totals
    int* student_total = new int[total_students]();
    int* subject_total = new int[total_subjects]();

    // Input grades and compute totals
    for (int i = 0; i < total_students; i++) {
        for (int j = 0; j < total_subjects; j++) {
            cout << "Enter grade of subject " << j + 1 << " for student " << i + 1 << ": ";
            cin >> grades[i][j];

            student_total[i] += grades[i][j];
            subject_total[j] += grades[i][j];
        }
    }

    // Output student totals
    cout << "\nSum of grades for each student:\n";
    for (int i = 0; i < total_students; i++) {
        cout << "Student " << i + 1 << ": " << student_total[i] << endl;
    }

    // Output subject averages
    cout << "\nAverage grade for each subject:\n";
    for (int i = 0; i < total_subjects; i++) {
        cout << "Subject " << i + 1 << ": " << double(subject_total[i]) / total_students << endl;
    }

    // Free allocated memory
    for (int i = 0; i < total_students; i++) {
        delete[] grades[i];
    }
    delete[] grades;

    delete[] student_total;
    delete[] subject_total;

    return 0;
}
