import React from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenu } from './';

export const Layout = ({ children }) => (
  <Grid fluid>
    <Row>
      <Col sm={3}>
        <NavMenu />
      </Col>
      <Col sm={9}>
        {children}
      </Col>
    </Row>
  </Grid>
);
