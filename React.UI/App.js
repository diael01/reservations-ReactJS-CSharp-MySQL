import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './src/Layout';
import { Home } from './src/Home';
import { Facilities } from './src/Facilities';


export default class App extends Component {

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />       
            <Route path='/facilities' component={Facilities} />
            <Route path='/test' component={Facilities} />
      </Layout>
    );
  }
}
