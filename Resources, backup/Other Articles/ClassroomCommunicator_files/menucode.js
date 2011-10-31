//// code for pop-up menus

// how it works:
//  When the mouse passes over one of the main navigation buttons, it calls
//   show_menu_exclusive() to swap the button image, open that button's pop-up menu,
//   and close any others that might be open.
//  When the mouse leaves the nav button, it starts a delayed restore of the button image
//   and closing of that pop-up menu by calling start_delayed_hide_menu(). The closing
//   is delayed because the mouse might be entering the pop-up menu. If not, then the menu
//   will either be closed by the delayed call to do_delayed_hide_menu(), or by entering
//   a different navigation button.
//  When the mouse enters a pop-up menu button, it cancels the delayed close of that
//   pop-up menu with cancel_delayed_hide_menu().
//  When the mouse leaves a pop-up menu button, it starts the delayed close.
//
//  In addition, the current section's menu is opened when no other menu is active.
//

//// globals

// active flag - allows menus to operate - set to true by set_current_section()
var menus_active = false;

// current section
// - for pages not in a section, such as tool pages, will be ""
var current_section = "";

// current page
// - for index pages, will be same as current_section
// - for tool pages and pages not in any subsection, will be ""
var current_page = "";

// menu currently open (names correspond to section names)
var open_menu = "";

// timer for delayed hide
var timerid = null;

//// functions

// set current section
//
function set_current_section(section, page) {

  // allow menu activity
  menus_active = true;

  // store section name as page name for index pages
  if (page == "index")
    page = section;

  // save current section and page
  current_section = section;
  current_page = page;

  // show menu for current section
  show_menu_exclusive(section);

  // display highlighted version of image
  if (page != section && page != "") { // do only for subsection pages
    var imgobj = MM_findObj(page);
    if (imgobj != null)
      imgobj.src = basegifsrc(imgobj.src) + "_hi.gif";
  }

}


// show main nav mouseover and corresponding pop-up menu (immediately hide previous, if any)
//
function show_menu_exclusive(menuname) {

  if (!menus_active) // don't do anything if menus not yet set up
    return;

  if (timerid != null) {        // cancel any delayed hides
    clearTimeout (timerid);
    timerid = null;
  }

  if (open_menu == menuname)  // return if this menu already open
    return;

  if (open_menu != "") {      // restore main navigation button
    // find image object
    var oldnavobj = MM_findObj(open_menu);
    // display unopen, unhighlighted button
    if (oldnavobj != null) {
      oldnavobj.src = basegifsrc(oldnavobj.src) + ".gif";
    }
    // hide the old pop-up menu
    var oldmenulayer = "menu" + open_menu;
    MM_showHideLayers(oldmenulayer,'','hide')
  }

  // swap in new menu button rollover and show pop-up menu

  if (menuname != "") {
    // find image object
    var navobj = MM_findObj(menuname);
    // display open or highlighted button
    if (navobj != null) {
      if (menuname == current_page)
        navobj.src = basegifsrc(navobj.src) + "_hi.gif";
      else
        navobj.src = basegifsrc(navobj.src) + "_open.gif";
    }
    // show the new pop-up menu
    var menulayer = "menu" + menuname;
    MM_showHideLayers(menulayer,'','show')
  }

  // record the open menu
  open_menu = menuname;
}

// this function is called when entering a primary navigation button,
// after displaying the menu
function primarynav_mouseover(sectionname) {
  var imgobj = MM_findObj(sectionname);
  if (imgobj != null) {
    imgobj.src = basegifsrc(imgobj.src) + "_hi.gif";
  }
}
// this function is called when leaving a primary navigation button,
//  before starting the delayed menu hide
// on an index page, keep displaying the highlighted version,
//  on other pages, display the open version
function primarynav_mouseout(sectionname) {
  var imgobj = MM_findObj(sectionname);
  if (imgobj != null) {
    if (sectionname == current_page)
      imgobj.src = basegifsrc(imgobj.src) + "_hi.gif";
    else
      imgobj.src = basegifsrc(imgobj.src) + "_open.gif";
  }
}


// start delayed main nav image restoration and pop-up menu hiding
//
function start_delayed_hide_menu() {
  if (!menus_active) // don't do anything if menus not yet set up
    return;

  timerid = setTimeout("do_delayed_hide_menu()", 50); // last arg is delay in milliseconds
}

// cancel delayed main nav image restoration and pop-up menu hiding
//
function cancel_delayed_hide_menu() {
  if (!menus_active) // don't do anything if menus not yet set up
    return;

  if (timerid != null) {
    clearTimeout (timerid);
    timerid = null;
  }
}

// perform delayed main nav image restoration and pop-up menu hiding
//
function do_delayed_hide_menu() {
  show_menu_exclusive(current_section);
}

function nav_preload() {
   // preload mouseovers for primary navigation
   MM_preloadImages('/img/nav/icampus_hi.gif','/img/nav/projects_hi.gif','/img/nav/themes_hi.gif','/img/nav/news_hi.gif','/img/nav/gallery_hi.gif');
   MM_preloadImages('/img/nav/icampus_open.gif','/img/nav/projects_open.gif','/img/nav/themes_open.gif','/img/nav/news_open.gif','/img/nav/gallery_open.gif');
   // preload mouseovers for menus
   MM_preloadImages('/img/menu/mitstrategy_hi.gif','/img/menu/microsoftgoals_hi.gif','/img/menu/bythenumbers_hi.gif');
   MM_preloadImages('/img/menu/faculty_hi.gif','/img/menu/students_hi.gif');
   MM_preloadImages('/img/menu/webservices_hi.gif','/img/menu/classroomtransform_hi.gif');
   MM_preloadImages('/img/menu/coverage_hi.gif','/img/menu/presskit_hi.gif','/img/menu/events_hi.gif');
   MM_preloadImages('/img/menu/images_hi.gif','/img/menu/video_hi.gif');
}


// utilities

// return base part of gif image src, with
// ".gif", "_hi.gif", or "_open.gif" removed
function basegifsrc(src) {
  var basesrc = src;
  var i;
  if ((i = src.lastIndexOf("_open.gif")) >= 0) {
    basesrc = src.substring(0,i);
  }
  else if ((i = src.lastIndexOf("_hi.gif")) >= 0) {
    basesrc = src.substring(0,i);
  }
  else if ((i = src.lastIndexOf(".gif")) >= 0) {
    basesrc = src.substring(0,i);
  }
  return basesrc;
}
