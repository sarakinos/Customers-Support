<?php

/*
|--------------------------------------------------------------------------
| Application Routes
|--------------------------------------------------------------------------
|
| Here is where you can register all of the routes for an application.
| It's a breeze. Simply tell Laravel the URIs it should respond to
| and give it the Closure to execute when that URI is requested.
|
*/

Route::get('/','PagesController@index')->before('auth');
Route::get('pelates','PagesController@pelates')->before('auth');
Route::get('rantevou','PagesController@rantevou')->before('auth');
Route::get('aitimata','PagesController@aitimata')->before('auth');
Route::get('leitourgies','PagesController@leitourgies')->before('auth');
Route::get('eortologio','PagesController@eortologio')->before('auth');
Route::post('pelatisAdd','PelatesController@store')->before('auth');
Route::post('pelatisDelete','PelatesController@destroy')->before('auth');
Route::post('pelatisEdit','PelatesController@edit')->before('auth');
Route::post('pelatisEditUpdate','PelatesController@update')->before('auth');

Route::post('aitimaAdd','AitimataController@store')->before('auth');
Route::post('aitimaDelete','AitimataController@destroy')->before('auth');
Route::post('aitimaEdit','AitimataController@edit')->before('auth');
Route::post('aitimaEditUpdate','AitimataController@update')->before('auth');

Route::post('rantevouAdd','RantevouController@store')->before('auth');
Route::post('rantevouDelete','RantevouController@destroy')->before('auth');
Route::post('rantevouEdit','RantevouController@edit')->before('auth');
Route::post('rantevouEditUpdate','RantevouController@update')->before('auth');

Route::post('findPelatisName','PelatesController@find')->before('auth');

Route::get('getEorti','EortologioController@returnEorti')->before('auth');

Route::post('sendMail','EmailController@sendMail')->before('auth');

Route::get('login','SessionsController@create');
Route::get('loginError','SessionsController@error');
Route::get('logout','SessionsController@destroy');

Route::post('sessionStore','SessionsController@store');
