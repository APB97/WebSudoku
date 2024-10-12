export function isMobile() {
    return /android|ios|mobile|phone/i.test(navigator.userAgent);
}

export function focusCell(row, column) {
    let cell = document.querySelector(`table.sudoku-table > tr:nth-child(${row}) > td:nth-child(${column}) > input`);
    cell.focus();
    cell.select();
}

export function blurCell(row, column) {
    let cell = document.querySelector(`table.sudoku-table > tr:nth-child(${row}) > td:nth-child(${column}) > input`);
    cell.blur();
}

export function selectCell(row, column) {
    let cell = document.querySelector(`table.sudoku-table > tr:nth-child(${row}) > td:nth-child(${column}) > input`);
    cell.select();
}