import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

class App extends Component {
  render() {

    var myStyle = {
      fontSize: 100,
      color: '#FF0000'
    };

    var arr = [
      <h1>数组元素1</h1>,
      <h2>数组元素2</h2>,
    ];

    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
        </p>
        <p data-myattribute = "somevalue">这里使用自定义属性。</p>
        <h1 style={myStyle}>这里使用内嵌样式。</h1>
        {/* 注释 */}
        <div>{arr}</div>
      </div>
    );
  }
}

export default App;
