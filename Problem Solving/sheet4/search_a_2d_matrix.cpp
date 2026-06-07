#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    bool searchMatrix(vector<vector<int>>& matrix, int target) {
        int rows = matrix.size();
        int cols = matrix[0].size();

        bool found = false;

        int low_row = 0;
        int high_row = rows - 1;
        
        while (low_row <= high_row) {
            int mid_row = low_row + (high_row - low_row) / 2;

            if (matrix[mid_row][0] < target) {
                low_row = mid_row + 1;
            } else {
                high_row = mid_row - 1;

                if (matrix[mid_row][0] == target) {
                    found = true;
                    break;
                }
            }
        }
        
        if (found) return true;

        if (low_row) low_row--;

        int low_col = 0;
        int high_col = cols - 1;
        
        while (low_col <= high_col) {
            int mid_col = low_col + (high_col - low_col) / 2;

            if (matrix[low_row][mid_col] < target) {
                low_col = mid_col + 1;
            } else {
                high_col = mid_col - 1;

                if (matrix[low_row][mid_col] == target) {
                    found = true;
                    break;
                }
            }
        }

        return found;
    }
};

int main() {
    Solution solution;

    vector<vector<int>> matrix;
    int target;

    matrix = {{1, 3, 5, 7}, {10, 11, 16, 20}, {23, 30, 34, 60}};
    target = 21;
    cout << solution.searchMatrix(matrix, target) << endl;

    matrix = {{1, 3, 5, 7}, {10, 11, 16, 20}, {23, 30, 34, 60}};
    target = 2;
    cout << solution.searchMatrix(matrix, target) << endl;

    matrix = {{1, 3, 5, 7}, {10, 11, 16, 20}, {23, 30, 34, 60}};
    target = 3;
    cout << solution.searchMatrix(matrix, target) << endl;

    matrix = {{1, 3, 5, 7}, {10, 11, 16, 20}, {23, 30, 34, 60}};
    target = 61;
    cout << solution.searchMatrix(matrix, target) << endl;

    return 0;
}
