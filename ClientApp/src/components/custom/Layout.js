import React from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenu } from './';

export const Layout = ({ children, alert }) => (
  <Grid fluid>
    <Row>
      <Col sm={3}>
        <NavMenu />
      </Col>
      <Col sm={9}>
        <Row>
          {alert.message &&
            <div className={`alert ${alert.type}`}>{alert.message}</div>
          }
        </Row>
        {children}
      </Col>
    </Row>
  </Grid>
);
