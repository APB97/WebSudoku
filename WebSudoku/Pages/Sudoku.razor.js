export function isFirefox()
{
    return /firefox/i.test(navigator.userAgent) && !/mobile/i.test(navigator.userAgent);
}

export function focusCell(row, column) {
    let cell = document.querySelector(`table.sudoku-table > tr:nth-child(${row}) > td:nth-child(${column}) > input`);
    cell.focus();
    cell.select();
}