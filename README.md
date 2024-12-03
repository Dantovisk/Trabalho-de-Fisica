# Lançamento Oblíquo - Jogo em Unity

## Descrição

Este é um jogo desenvolvido na Unity que simula o lançamento oblíquo de projéteis, permitindo que o jogador ajuste parâmetros físicos como a massa do projétil, a velocidade de lançamento e o coeficiente de arrasto para alcançar um alvo. O jogo oferece fases com diferentes ambientes e diferentes propriedades físicas, tornando o jogo mais interessante.

## Funcionalidade

- **Massa do Projétil**: O jogador pode selecionar a massa do projétil. A massa influencia a aceleração e a trajetória do projétil, conforme descrito pelas leis de Newton.
- **Velocidade Inicial**: O jogador pode ajustar a velocidade inicial do projétil. Essa velocidade define a direção e a magnitude do movimento do projétil.
- **Coeficiente de Arrasto**: A resistência do ar (ou água) pode ser modificada, o que afeta o movimento do projétil devido à força de arrasto. O coeficiente de arrasto influencia a desaceleração do projétil ao longo do tempo.

## Física do Jogo

O jogo simula o lançamento oblíquo de um projétil, levando em consideração a física básica do movimento em um campo gravitacional, sem calcular a força de arrasto diretamente. A física utilizada é baseada nas equações clássicas de movimento:

### 1. Movimento Vertical

O movimento vertical do projétil é governado pela segunda lei de Newton, com a aceleração devido à gravidade $g$ (aproximadamente $9.81 \, m/s^2$ na Terra). A fórmula que descreve a posição vertical $y(t)$ ao longo do tempo $t$ é:

$$
y(t) = y_0 + v_{y0} \cdot t - \frac{1}{2} g t^2
$$

Onde:
- $y_0$ é a posição inicial vertical do projétil.
- $v_{y0}$ é a componente vertical da velocidade inicial.
- $g$ é a aceleração devida à gravidade.
- $t$ é o tempo.

A velocidade vertical do projétil é dada por:

$$
v_y(t) = v_{y0} - g t
$$

### 2. Movimento Horizontal

O movimento horizontal não sofre aceleração, pois não há forças externas atuando sobre o projétil (exceto o arrasto, que não é calculado diretamente aqui). A posição horizontal $x(t)$ ao longo do tempo é dada por:

$$
x(t) = x_0 + v_{x0} \cdot t
$$

Onde:
- $x_0$ é a posição inicial horizontal do projétil.
- $v_{x0}$ é a componente horizontal da velocidade inicial.
- $t$ é o tempo.

### 3. Componentes da Velocidade Inicial

A velocidade inicial $v_0$ é decomposta em duas componentes:
- Componente horizontal $v_{x0} = v_0 \cdot \cos(\theta)$
- Componente vertical $v_{y0} = v_0 \cdot \sin(\theta)$

Onde:
- $v_0$ é a velocidade inicial.
- $\theta$ é o ângulo de lançamento.

### 4. Aceleração e Movimento por Quadro

Em cada quadro (frame) do jogo, a aceleração do projétil é calculada levando em consideração a gravidade e a massa . A cada iteração, a velocidade é atualizada e a nova posição é calculada com base na velocidade do projétil.

A aceleração é dada pela equação de movimento de Newton:

$$
F = m \cdot a
$$

Onde $F$ é a força resultante (neste caso, apenas a gravidade) e $m$ é a massa do projétil. A aceleração $a$ é, portanto, a razão entre a força e a massa:

$$
a = \frac{F}{m}
$$

### 5. Simulação de Lançamento em Água

Em fases subaquáticas, a resistência do meio (água) é maior do que no ar. Embora o cálculo da força de arrasto não seja realizado diretamente no código, a física subaquática pode ser representada pela modificação do coeficiente de arrasto para refletir a maior viscosidade da água.


## Tecnologias Usadas

- Unity 2023.x
- C#
- Física 2D (Movimento de Projetéis)

