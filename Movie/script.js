const API_KEY ='api_key=118a1dc490ea54a28867c254a344c81c';
const BASE_URL ='https://api.themoviedb.org/3';
const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;
const IMG_URL = 'https://image.tmdb.org/t/p/w500/';
const SEARCH_URL = BASE_URL + '/search/movie?' + API_KEY;

const genres = [
    {
       "id":28,
       "name":"Action"
    },
    {
       "id":12,
       "name":"Adventure"
    },
    {
       "id":16,
       "name":"Animation"
    },
    {
       "id":35,
       "name":"Comedy"
    },
    {
       "id":80,
       "name":"Crime"
    },
    {
       "id":99,
       "name":"Documentary"
    },
    {
       "id":18,
       "name":"Drama"
    },
    {
       "id":10751,
       "name":"Family"
    },
    {
       "id":14,
       "name":"Fantasy"
    },
    {
       "id":36,
       "name":"History"
    },
    {
       "id":27,
       "name":"Horror"
    },
    {
       "id":10402,
       "name":"Music"
    },
    {
       "id":9648,
       "name":"Mystery"
    },
    {
       "id":10749,
       "name":"Romance"
    },
    {
       "id":878,
       "name":"Science Fiction"
    },
    {
       "id":10770,
       "name":"TV Movie"
    },
    {
       "id":53,
       "name":"Thriller"
    },
    {
       "id":10752,
       "name":"War"
    },
    {
       "id":37,
       "name":"Western"
    }
 ]

 const languange = [
   { "code": "aa", "name": "Afar" },
   { "code": "ab", "name": "Abkhazian" },
   { "code": "ae", "name": "Avestan" },
   { "code": "af", "name": "Afrikaans" },
   { "code": "ak", "name": "Akan" },
   { "code": "am", "name": "Amharic" },
   { "code": "an", "name": "Aragonese" },
   { "code": "ar", "name": "Arabic" },
   { "code": "as", "name": "Assamese" },
   { "code": "av", "name": "Avaric" },
   { "code": "ay", "name": "Aymara" },
   { "code": "az", "name": "Azerbaijani" },
   { "code": "ba", "name": "Bashkir" },
   { "code": "be", "name": "Belarusian" },
   { "code": "bg", "name": "Bulgarian" },
   { "code": "bh", "name": "Bihari languages" },
   { "code": "bi", "name": "Bislama" },
   { "code": "bm", "name": "Bambara" },
   { "code": "bn", "name": "Bengali" },
   { "code": "bo", "name": "Tibetan" },
   { "code": "br", "name": "Breton" },
   { "code": "bs", "name": "Bosnian" },
   { "code": "ca", "name": "Catalan; Valencian" },
   { "code": "ce", "name": "Chechen" },
   { "code": "ch", "name": "Chamorro" },
   { "code": "co", "name": "Corsican" },
   { "code": "cr", "name": "Cree" },
   { "code": "cs", "name": "Czech" },
   {
     "code": "cu",
     "name": "Church Slavic; Old Slavonic; Church Slavonic; Old Bulgarian; Old Church Slavonic"
   },
   { "code": "cv", "name": "Chuvash" },
   { "code": "cy", "name": "Welsh" },
   { "code": "da", "name": "Danish" },
   { "code": "de", "name": "German" },
   { "code": "dv", "name": "Divehi; Dhivehi; Maldivian" },
   { "code": "dz", "name": "Dzongkha" },
   { "code": "ee", "name": "Ewe" },
   { "code": "el", "name": "Greek, Modern (1453-)" },
   { "code": "en", "name": "English" },
   { "code": "eo", "name": "Esperanto" },
   { "code": "es", "name": "Spanish; Castilian" },
   { "code": "et", "name": "Estonian" },
   { "code": "eu", "name": "Basque" },
   { "code": "fa", "name": "Persian" },
   { "code": "ff", "name": "Fulah" },
   { "code": "fi", "name": "Finnish" },
   { "code": "fj", "name": "Fijian" },
   { "code": "fo", "name": "Faroese" },
   { "code": "fr", "name": "French" },
   { "code": "fy", "name": "Western Frisian" },
   { "code": "ga", "name": "Irish" },
   { "code": "gd", "name": "Gaelic; Scomttish Gaelic" },
   { "code": "gl", "name": "Galician" },
   { "code": "gn", "name": "Guarani" },
   { "code": "gu", "name": "Gujarati" },
   { "code": "gv", "name": "Manx" },
   { "code": "ha", "name": "Hausa" },
   { "code": "he", "name": "Hebrew" },
   { "code": "hi", "name": "Hindi" },
   { "code": "ho", "name": "Hiri Motu" },
   { "code": "hr", "name": "Croatian" },
   { "code": "ht", "name": "Haitian; Haitian Creole" },
   { "code": "hu", "name": "Hungarian" },
   { "code": "hy", "name": "Armenian" },
   { "code": "hz", "name": "Herero" },
   {
     "code": "ia",
     "name": "Interlingua (International Auxiliary Language Association)"
   },
   { "code": "id", "name": "Indonesian" },
   { "code": "ie", "name": "Interlingue; Occidental" },
   { "code": "ig", "name": "Igbo" },
   { "code": "ii", "name": "Sichuan Yi; Nuosu" },
   { "code": "ik", "name": "Inupiaq" },
   { "code": "io", "name": "Ido" },
   { "code": "is", "name": "Icelandic" },
   { "code": "it", "name": "Italian" },
   { "code": "iu", "name": "Inuktitut" },
   { "code": "ja", "name": "Japanese" },
   { "code": "jv", "name": "Javanese" },
   { "code": "ka", "name": "Georgian" },
   { "code": "kg", "name": "Kongo" },
   { "code": "ki", "name": "Kikuyu; Gikuyu" },
   { "code": "kj", "name": "Kuanyama; Kwanyama" },
   { "code": "kk", "name": "Kazakh" },
   { "code": "kl", "name": "Kalaallisut; Greenlandic" },
   { "code": "km", "name": "Central Khmer" },
   { "code": "kn", "name": "Kannada" },
   { "code": "ko", "name": "Korean" },
   { "code": "kr", "name": "Kanuri" },
   { "code": "ks", "name": "Kashmiri" },
   { "code": "ku", "name": "Kurdish" },
   { "code": "kv", "name": "Komi" },
   { "code": "kw", "name": "Cornish" },
   { "code": "ky", "name": "Kirghiz; Kyrgyz" },
   { "code": "la", "name": "Latin" },
   { "code": "lb", "name": "Luxembourgish; Letzeburgesch" },
   { "code": "lg", "name": "Ganda" },
   { "code": "li", "name": "Limburgan; Limburger; Limburgish" },
   { "code": "ln", "name": "Lingala" },
   { "code": "lo", "name": "Lao" },
   { "code": "lt", "name": "Lithuanian" },
   { "code": "lu", "name": "Luba-Katanga" },
   { "code": "lv", "name": "Latvian" },
   { "code": "mg", "name": "Malagasy" },
   { "code": "mh", "name": "Marshallese" },
   { "code": "mi", "name": "Maori" },
   { "code": "mk", "name": "Macedonian" },
   { "code": "ml", "name": "Malayalam" },
   { "code": "mn", "name": "Mongolian" },
   { "code": "mr", "name": "Marathi" },
   { "code": "ms", "name": "Malay" },
   { "code": "mt", "name": "Maltese" },
   { "code": "my", "name": "Burmese" },
   { "code": "na", "name": "Nauru" },
   {
     "code": "nb",
     "name": "Bokmål, Norwegian; Norwegian Bokmål"
   },
   { "code": "nd", "name": "Ndebele, North; North Ndebele" },
   { "code": "ne", "name": "Nepali" },
   { "code": "ng", "name": "Ndonga" },
   { "code": "nl", "name": "Dutch; Flemish" },
   { "code": "nn", "name": "Norwegian Nynorsk; Nynorsk, Norwegian" },
   { "code": "no", "name": "Norwegian" },
   { "code": "nr", "name": "Ndebele, South; South Ndebele" },
   { "code": "nv", "name": "Navajo; Navaho" },
   { "code": "ny", "name": "Chichewa; Chewa; Nyanja" },
   { "code": "oc", "name": "Occitan (post 1500)" },
   { "code": "oj", "name": "Ojibwa" },
   { "code": "om", "name": "Oromo" },
   { "code": "or", "name": "Oriya" },
   { "code": "os", "name": "Ossetian; Ossetic" },
   { "code": "pa", "name": "Panjabi; Punjabi" },
   { "code": "pi", "name": "Pali" },
   { "code": "pl", "name": "Polish" },
   { "code": "ps", "name": "Pushto; Pashto" },
   { "code": "pt", "name": "Portuguese" },
   { "code": "qu", "name": "Quechua" },
   { "code": "rm", "name": "Romansh" },
   { "code": "rn", "name": "Rundi" },
   { "code": "ro", "name": "Romanian; Moldavian; Moldovan" },
   { "code": "ru", "name": "Russian" },
   { "code": "rw", "name": "Kinyarwanda" },
   { "code": "sa", "name": "Sanskrit" },
   { "code": "sc", "name": "Sardinian" },
   { "code": "sd", "name": "Sindhi" },
   { "code": "se", "name": "Northern Sami" },
   { "code": "sg", "name": "Sango" },
   { "code": "si", "name": "Sinhala; Sinhalese" },
   { "code": "sk", "name": "Slovak" },
   { "code": "sl", "name": "Slovenian" },
   { "code": "sm", "name": "Samoan" },
   { "code": "sn", "name": "Shona" },
   { "code": "so", "name": "Somali" },
   { "code": "sq", "name": "Albanian" },
   { "code": "sr", "name": "Serbian" },
   { "code": "ss", "name": "Swati" },
   { "code": "st", "name": "Sotho, Southern" },
   { "code": "su", "name": "Sundanese" },
   { "code": "sv", "name": "Swedish" },
   { "code": "sw", "name": "Swahili" },
   { "code": "ta", "name": "Tamil" },
   { "code": "te", "name": "Telugu" },
   { "code": "tg", "name": "Tajik" },
   { "code": "th", "name": "Thai" },
   { "code": "ti", "name": "Tigrinya" },
   { "code": "tk", "name": "Turkmen" },
   { "code": "tl", "name": "Tagalog" },
   { "code": "tn", "name": "Tswana" },
   { "code": "to", "name": "Tonga (Tonga Islands)" },
   { "code": "tr", "name": "Turkish" },
   { "code": "ts", "name": "Tsonga" },
   { "code": "tt", "name": "Tatar" },
   { "code": "tw", "name": "Twi" },
   { "code": "ty", "name": "Tahitian" },
   { "code": "ug", "name": "Uighur; Uyghur" },
   { "code": "uk", "name": "Ukrainian" },
   { "code": "ur", "name": "Urdu" },
   { "code": "uz", "name": "Uzbek" },
   { "code": "ve", "name": "Venda" },
   { "code": "vi", "name": "Vietnamese" },
   { "code": "vo", "name": "Volapük" },
   { "code": "wa", "name": "Walloon" },
   { "code": "wo", "name": "Wolof" },
   { "code": "xh", "name": "Xhosa" },
   { "code": "yi", "name": "Yiddish" },
   { "code": "yo", "name": "Yoruba" },
   { "code": "za", "name": "Zhuang; Chuang" },
   { "code": "zh", "name": "Chinese" },
   { "code": "zu", "name": "Zulu" }
 ]

const main = document.getElementById('main');
const form = document.getElementById('form');
const search = document.getElementById('search');

const tagElement = document.getElementById('tags');

const prev = document.getElementById('prev');
const current = document.getElementById('current');
const next = document.getElementById('next');
/* const tryBtn = document.getElementById('tryBtn'); */

var currentPage = 1;
var nextPage = 2;
var prevPage = 3;
var lastUrl = '';
var totalPages = 100;

setGenre();

var selectedGenre = [];

function setGenre(){
   tagElement.innerHTML = '';

   genres.forEach(genre =>{
      const t = document.createElement('div');
      t.classList.add('tag');
      t.id = genre.id;
      t.innerText = genre.name;
      t.addEventListener('click', () => {
         if(selectedGenre.length == 0) {
            selectedGenre.push(genre.id);
         } else {
            if(selectedGenre.includes(genre.id)){
               selectedGenre.forEach((id, idx) => {
                  if(id == genre.id){
                     selectedGenre.splice(idx, 1);
                  }
               })
            } else {
               selectedGenre.push(genre.id);
            }
         }
         console.log(selectedGenre);
         getMovies(API_URL + '&with_genres=' + encodeURI(selectedGenre.join(',')))
         highlightSelection()
      })
      tags.append(t);
   })
}

function highlightSelection(){
   const tags = document.querySelectorAll('.tag');
   tags.forEach(tag => {
      tag.classList.remove('highlight');
   })

   clearBtn();

   if(selectedGenre.length != 0){
      selectedGenre.forEach(id => {
         const highlightedTag = document.getElementById(id);
         highlightedTag.classList.add('highlight');
      })
   }
}

/* const detail = document.getElementById('button'); */

function clearBtn(){
   let clearBtn = document.getElementById('clear');
   if(clearBtn){
      clearBtn.classList.add('highlightclr')
   } else {
      let clear = document.createElement('div');
      clear.classList.add('tag','highlightclr');
      clear.id = 'clear';
      clear.innerText = 'Clear X';
      clear.addEventListener('click', () => {
         selectedGenre = [];
         setGenre();
         getMovies(API_URL);
      })
      tagElement.append(clear);
   }
}

getMovies(API_URL);

function getMovies(url){
   lastUrl = url;
   
   main.innerHTML ='';
    
    fetch(url).then(res => res.json()).then(data =>{
        console.log(data.results);
        if(data.results.length !== 0) {
            showMovies(data.results);
            currentPage = data.page;
            nextPage = currentPage + 1;
            prevPage = currentPage - 1;
            totalPages = data.total_pages;
            
            current.innerText = currentPage;

            if(currentPage <= 1){
               prev.classList.add('disabled');
               next.classList.remove('disabled');
            } else if (currentPage >= totalPages) {
               prev.classList.remove('disabled');
               next.classList.add('disabled');
            } else {
               prev.classList.remove('disabled');
               next.classList.remove('disabled');
            }

            tagElement.scrollIntoView({behavior : 'smooth'});

        } else {
            main.innerHTML = `<h1 class="no-results"> Sorry! There is no result found! </h1>`
        }
        /* movieDetails(data.results); */
    })
}

/* function movieDetails(data){
    console.log("Hello");
} */

function showMovies(data){
    data.forEach(movie =>{
        const{title, poster_path, vote_average,overview, id} = movie;
        const movieEl = document.createElement('div');
        movieEl.classList.add('movie');
        movieEl.innerHTML = `
        <img src="${poster_path? IMG_URL+poster_path: "/movie/assets/NoImage.png" }" alt="${title}">

            <div class="movie-info">
                <h3>${title}</h3>
                <span class="${getColor(vote_average)}">${vote_average}</span>
            </div>

            <div class="overview">
                ${overview? overview: "<span> No overview found! </span>"}
                <br/>
                <div class="trailer-detail">
                  <button class="trailer" id="${id}">Trailer</button>
                  <button class="detail" id="${id + 's'}">Details</button>
                </div>
            </div>
            
            <!-- <div class="button">
			    <button type="button" id="btn" onclick="movieDetails()">Details</button>
		    </div> -->`

        main.appendChild(movieEl);

        document.getElementById(id).addEventListener('click', () =>{
         openNav(movie);
        })

        document.getElementById(id + 's').addEventListener('click', () =>{
         console.log(movie)
         openDetailNav(movie);
        })
    })
}

const overlayContent = document.getElementById('overlay-content');

/* Open when someone clicks on the span element */
function openNav(movie) {
   let id = movie.id;
   fetch(BASE_URL + '/movie/' + id + '/videos?' + API_KEY).then(res => res.json()).then(videoData => {
      console.log(videoData);
      if(videoData){
         document.getElementById("myNav").style.width = "100%";
         if(videoData.results.length > 0){
            var embed = [];
            var dots = [];
            videoData.results.forEach((video, idx) =>{
               let {name, key, site} = video
               if(site == 'YouTube') {
                  embed.push(`
                  <iframe width="560" height="315" src="https://www.youtube.com/embed/${key}" title="${name}" class="embed hide" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                  `)

                  dots.push(`
                  <span class="dot">${idx + 1}</span>
                  `)
               }
            })

            var content = `
            <h1 class="no-results">${movie.original_title}</h1>
            <br/>

            ${embed.join('')}
            <br/>

            <div class="dots">${dots.join('')}</div>
            `
            overlayContent.innerHTML = content;
            activeSlide = 0;
            showVideo();
         } else {
            overlayContent.innerHTML = `<h1 class="no-results"> No results found!</h1>`
         }
      }
   })
 }
 
 const overlayContent2 = document.getElementById('overlay-content2');

/* Open */
function openDetailNav(movie) {
   /* let id = movie.id; */

   document.getElementById("detailNav").style.width = "100%";

   genres.forEach((genre, indx) =>{
      for(let i=0; i<movie.genre_ids.length; i++){
         if(genre.id == movie.genre_ids[i]){
            /* console.log(genre.id + '/' + genre.name); 
            console.log(movie.genre_ids[i]);  */
            movie.genre_ids[i] = genre.name;
         }
      }
      
      /* console.log(indx);
      console.log("movie genre:" + movie.genre_ids); */
   })

   languange.forEach((lang) =>{
      if(lang.code == movie.original_language) {
         movie.original_language = lang.name;
      }
   })

   var content2 = `
            <h1 class="no-results">Movie Title: ${movie.original_title}</h1>
            <img src="${movie.poster_path? IMG_URL+movie.poster_path: "/movie/assets/NoImage.png" }" alt="${movie.title}">
            <h3 class="no-results">Release Date: ${movie.release_date}</h3>
            <h3 class="no-results">Genre: ${movie.genre_ids}</h3>
            <h3 class="no-results">Language: ${movie.original_language}</h3>
            <h3 class="no-results">Overview: ${movie.overview}</h3>
            <h3 class="no-results">Vote Average: ${movie.vote_average}</h3>
            <h3 class="no-results">Vote Count: ${movie.vote_count}</h3>
            <br/>
            `
      overlayContent2.innerHTML = content2;
      activeSlide = 0;
 }

 const overlayContent3 = document.getElementById('overlay-content3');

 /* Open */
 /* function openGenreNav() {
 
   document.getElementById("genreNav").style.width = "100%";
 
   var content3 = `
             <h1 class="no-results">Genre</h1>
             `
   overlayContent3.innerHTML = content3;
   activeSlide = 0;
  } */
 

 /* Close when someone clicks on the "x" symbol inside the overlay */
 function closeNav() {
   document.getElementById("myNav").style.width = "0%";
   document.getElementById("detailNav").style.width = "0%";
   /* document.getElementById("genreNav").style.width = "0%"; */
 }


 var activeSlide = 0;
 var totalVideos = 0;
 
 function showVideo(){
   let embedClasses = document.querySelectorAll('.embed');
   let dots = document.querySelectorAll('.dot');

   totalVideos = embedClasses.length;
   embedClasses.forEach((embedTag, idx) => {
      if(activeSlide == idx){
         embedTag.classList.add('show');
         embedTag.classList.remove('hide');
      } else {
         embedTag.classList.add('hide');
         embedTag.classList.remove('show');
      }
   })

   dots.forEach((dot, indx) => {
      if(activeSlide == indx){
         dot.classList.add('active');
      } else {
         dot.classList.remove('active');
      }
   })
 }

 const leftArrow = document.getElementById('left-arrow');
 const rightArrow = document.getElementById('right-arrow');

 leftArrow.addEventListener('click', () => {
   if(activeSlide > 0){
      activeSlide--;
   } else {
      activeSlide = totalVideos -1;
   }
   showVideo()
 })

 rightArrow.addEventListener('click', () => {
   if(activeSlide < (totalVideos -1)){
      activeSlide++;
   } else {
      activeSlide = totalVideos -1;
   }
   showVideo()
 })

function getColor(vote){
    if(vote >= 8 ){
        return 'green'
    }else if(vote >= 5){
        return 'orange'
    }else{
        return 'red'
    }
}

form.addEventListener('submit', (e) => {
    e.preventDefault();

    const searchTerm = search.value;
    selectedGenre = [];
    setGenre();

    if(searchTerm) {
        getMovies(SEARCH_URL + '&query=' +searchTerm)
    }else {
        getMovies(API_URL);
    }
})

prev.addEventListener('click', () => {
   if(prevPage > 0){
      pageCall(prevPage);
   }
})

next.addEventListener('click', () => {
   if(nextPage <= totalPages){
      pageCall(nextPage);
   }
})

function pageCall(page){
   let urlSplit = lastUrl.split('?');
   let queryParams = urlSplit[1].split('&');
   let key = queryParams[queryParams.length - 1].split('=');
   if(key[0] != 'page'){
      let url = lastUrl + '&page=' + page;
      getMovies(url);
   } else {
      key[1] = page.toString();
      let a = key.join('=');
      queryParams[queryParams.length - 1] = a;
      let b = queryParams.join('&');
      let url = urlSplit[0] + '?' + b;
      getMovies(url);
   }
}

function gHome() {
   getMovies(API_URL);
   setGenre();
   selectedGenre = [];
}

/* function gGenre() {
   console.log("Genre");
   openGenreNav();
} */

/* for (var i = 0 ; i < detail.length; i++) {
    detail[i].addEventListener('click', ()=> {
        console.log("Hello"); 
    })
} */

/* tryBtn.addEventListener('click', () => {
      console.log("hello");
}) */

