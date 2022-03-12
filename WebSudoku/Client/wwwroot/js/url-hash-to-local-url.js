if (window.location.hash.length > 1) {
    const path = window.location.hash.replace('#', '')
    history.pushState({ page: 1 }, "Web Sudoku", '/WebSudoku' + path)
}