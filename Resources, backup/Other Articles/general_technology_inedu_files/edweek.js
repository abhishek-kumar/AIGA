/* EdWeek Global Javascript */

/* writeAddr for email addresses */
function writeAddr() {
	// Build the address
	var i,a=writeAddr.arguments,addr="";
	addr += a[0]+"@";
	for( i=1; i<a.length; i++ ) {
		if( i>1 ) addr += ".";
		addr += a[i];
	}
	// Write html to the browser with the email address
	parent.location = "mailto:" + addr;
}

/* http://www.kryogenix.org/code/browser/searchhi/ */
function highlightWord(node,word) {
	// Iterate into this nodes childNodes
	
	if (node && node.hasChildNodes) {
		var hi_cn;
		for (hi_cn=0;hi_cn<node.childNodes.length;hi_cn++) {
			highlightWord(node.childNodes[hi_cn],word);
		}
	}
	
	// And do this node itself
	if (node && node.nodeType == 3) { // text node
			
		tempNodeVal = node.nodeValue.toLowerCase();
		tempWordVal = word.toLowerCase();
		if (tempNodeVal.indexOf(tempWordVal) != -1) {
			pn = node.parentNode;
			if (pn.className != "searchword") {
				// word has not already been highlighted!
				nv = node.nodeValue;
				ni = tempNodeVal.indexOf(tempWordVal);
				// Create a load of replacement nodes
				before = document.createTextNode(nv.substr(0,ni));
				docWordVal = nv.substr(ni,word.length);
				after = document.createTextNode(nv.substr(ni+word.length));
				hiwordtext = document.createTextNode(docWordVal);
				hiword = document.createElement("span");
				hiword.className = "searchword";
				hiword.appendChild(hiwordtext);
				pn.insertBefore(before,node);
				pn.insertBefore(hiword,node);
				pn.insertBefore(after,node);
				pn.removeChild(node);
			}
		}
	}
}

function b2SearchHighlight() {

	if (!document.createElement) return;
	if (document.getElementById('layout-3col'))
			node = document.getElementById('col2');
	else if (document.getElementById('container')) // blog		
			node = document.getElementById('alpha-inner');
	else		
			node = document.getElementById('col1');
	ref = window.location.href;
	if (ref.indexOf('?') == -1) return;
	qs = ref.substr(ref.indexOf('?')+1);
	qsa = qs.split('&');
	for (i=0;i<qsa.length;i++) 
	{
		qsip = qsa[i].split('=');
    if (qsip.length == 1) continue;
  	if (qsip[0] == 'qs') 
  	{
			words = unescape(qsip[1].replace(/\+/g,' ')).split(/\s+/);
	    for (w=0;w<words.length;w++) 
	    {
	    	
	    	if (words[w].length > 1)
	    	{
	    		words[w] = words[w].replace(/_/g, ' ');
					highlightWord(node,words[w]);
				}
	  	}
    }
	}
}

/* - DISABLE SEARCH HIGHLIGHT */
 window.onload = function(){timeID = setTimeout('b2SearchHighlight()',500)}
/* - DISABLE SEARCH HIGHLIGHT */


function popUp( url, options ) {
	var winName = '';
	if( arguments && arguments[2] ) {
		winName = arguments[2];
	}	else {
		winName = "edweekPopup";
	}
	window.open( url, winName, options );
}

// Random encryption key feature by Andrew Moulden, Site Engineering Ltd
// This code is freeware provided these four comment lines remain intact
// A wizard to generate this code is at http://www.jottings.com/obfuscator/

var __MTTBLINK__;
var __MTTBID__;
function obfuscator(coded, key, mode, path, hidden) {
	shift = coded.length;
	link = "";
	
	for(i=0;i<coded.length;i++) {
		if (key.indexOf(coded.charAt(i))==-1) {
			ltr = coded.charAt(i);link+=(ltr);
		} else {
			ltr = (key.indexOf(coded.charAt(i)) - shift + key.length) % key.length;
			link += (key.charAt(ltr));
		}
	}
	if(mode == 'hidden_input') {
		document.write('<input type="hidden" name="CCode" value="' + link + '" />');
	} else if(mode == '__MTTBLINK__') {
		__MTTBLINK__ = path + link;
		if(hidden) return;
		document.write(link);
	} else if(mode == '__MTTBID__') {
		__MTTBID__ = link;
		if(hidden) return;
		document.write(link);
	}
}
