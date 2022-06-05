
function shortdate(dateString) {

    const short = new Date(dateString).toLocaleDateString('en-US');
    return short;
}