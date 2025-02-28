function find (text, word){
    let pattern = `\\b${word}\\b`;
    const regEx = new RegExp(pattern, 'g');
    const result = text.match(regEx) || [];

    console.log(result.length);
}

find('This is a word and it also is a sentence','is');
find('softuni is great place for learning new programming languages','softuni');