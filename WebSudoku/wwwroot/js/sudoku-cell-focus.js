function focusCell(row, column) {
    let cell = document.querySelector(`table.sudoku-table > tr:nth-child(${row}) > td:nth-child(${column}) > input`);
    cell.focus();
    cell.select();
}