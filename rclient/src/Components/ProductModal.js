import { useEffect, useState } from 'react';
import { Modal, Form, Button, FormGroup, FormLabel, FormControl } from 'react-bootstrap';

const ProductModal = ({ show, onClose }) => {
  const [categoryList, setCategoryList] = useState([]);
  const [name, setproductName] = useState([]);
  const [categoryId, setcategoryId] = useState([]);
  const [price, setPrice] = useState([]);

  const getCategoriesAsync = async () => {
    const response = await fetch('http://localhost:5041/api/category');
    const categories = await response.json();

    setCategoryList(categories);
  };

  useEffect(() => {
    getCategoriesAsync();
  }, []);

  const createNewProduct = async () => {
    const newProduct = { name, categoryId, price };
    const response = await fetch(
      'http://localhost:5041/api/Product',

      {
        method: 'POST',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(newProduct),
      }
    );
    onClose();
  };

  return (
    <Modal show={show} onHide={onClose}>
      <Modal.Header closeButton>
        <Modal.Title>Create New Product</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form onSubmit={createNewProduct} className="d-flex flex-column gap-3">
          <FormGroup>
            <FormLabel>Product Name</FormLabel>
            <FormControl
              type="text"
              onChange={(e) => setproductName(e.target.value)}
            ></FormControl>
          </FormGroup>
          <FormGroup>
            <FormLabel>Product Price</FormLabel>
            <FormControl
              type="money"
              onChange={(e) => setPrice(e.target.value)}
            ></FormControl>
          </FormGroup>
          <FormGroup>
            <FormLabel>Product category</FormLabel>
            <FormControl as={'select'} onChange={(e) => setcategoryId(e.target.value)}>
              <option value={0}>Select An Option</option>
              {categoryList.map((c) => {
                return (
                  <option key={c.id} value={c.id}>
                    {c.name}
                  </option>
                );
              })}
            </FormControl>
          </FormGroup>
          <Button variant="primary" type="submit" className="w-100 mt-3">
            {' '}
            Create Product
          </Button>
        </Form>
      </Modal.Body>
    </Modal>
  );
};

export default ProductModal;
